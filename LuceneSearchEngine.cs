using System;
using Lucene.Net.Analysis; // for Analyser
using Lucene.Net.Documents; // for Document and Field
using Lucene.Net.Index; //for Index Writer
using Lucene.Net.Store; //for Directory
using Lucene.Net.Search; // for IndexSearcher
using Lucene.Net.QueryParsers;  // for QueryParser
using WindowsFormsApp1;
using System.Collections.Generic;
using Lucene.Net.Analysis.Tokenattributes;

class LuceneSearchEngine
{

    Lucene.Net.Store.Directory luceneIndexDirectory;
    Lucene.Net.Analysis.Analyzer analyzer;
    Lucene.Net.Index.IndexWriter writer;
    IndexSearcher searcher;
    QueryParser parser;

    const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
    public readonly string[] FIELDS_FN = { "is_selected", "url", "passage_text", "passage_id" };

    public LuceneSearchEngine()
    {
        luceneIndexDirectory = null;
        writer = null;
        analyzer = new Lucene.Net.Analysis.Standard.StandardAnalyzer(VERSION);
    }

    public List<string> TokenizeString(string untokenized)
    {
        System.IO.StringReader stringReader = new System.IO.StringReader(untokenized);
        TokenStream tokenStream = analyzer.TokenStream("text", stringReader);
        List<string> tokenized = new List<string>();
        ITermAttribute termAtt = tokenStream.GetAttribute<ITermAttribute>();
        while (tokenStream.IncrementToken())
        {
            tokenized.Add(termAtt.Term);
        }
        return tokenized;
    }

    /// <summary>
    /// Creates the index at a given path
    /// </summary>
    /// <param name="indexPath">The pathname to create the index</param>
    public void CreateIndex(string indexPath)
    {
        luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);
        IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
        writer = new Lucene.Net.Index.IndexWriter(luceneIndexDirectory, analyzer, true, mfl);
    }

    public void LoadIndex(string indexPath)
    {
        luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);      
    }

    /// <summary>
    /// Indexes a given Rootobject into the index
    /// </summary>
    /// <param name="root">The Rootobject to index</param>
    public void IndexRootobject(Rootobject root)
    {
        
        foreach (Passage passage in root.passages)
        {
            
            Lucene.Net.Documents.Document doc = new Document();
            Lucene.Net.Documents.NumericField isSelectedField = new NumericField(FIELDS_FN[0], Field.Store.YES, true);
            isSelectedField.SetIntValue(passage.is_selected);
            doc.Add(isSelectedField);
            if (!String.IsNullOrEmpty(passage.url))
            {
                Lucene.Net.Documents.Field urlField = new Field(FIELDS_FN[1], passage.url, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES);
                doc.Add(urlField);
            }
            if (!String.IsNullOrEmpty(passage.passage_text))
            {
                Lucene.Net.Documents.Field passageTextField = new Field(FIELDS_FN[2], passage.passage_text, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES);
                doc.Add(passageTextField);
            }
            Lucene.Net.Documents.NumericField passageIDField = new NumericField(FIELDS_FN[3], Field.Store.YES, true);
            passageIDField.SetIntValue(passage.passage_ID);
            doc.Add(passageIDField);
          
            writer.AddDocument(doc);

            //Commented out code for indexing query data in json file
            /*Lucene.Net.Documents.NumericField passageField = new NumericField("passage"+passage.passage_ID, Field.Store.YES, true);
            passageField.SetIntValue(passage.passage_ID);
            doc.Add(passageField);*/
        }
        //Commented out code for indexing query data in json file
        /*Lucene.Net.Documents.NumericField queryIDField = new NumericField("query_id", Field.Store.YES, true);
        queryIDField.SetIntValue(root.query_id);
        doc.Add(queryIDField);
        int i = 0;
        foreach(string answer in root.answers)
        {
            Lucene.Net.Documents.Field answerField = new Field("answer"+i, answer, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES);
            doc.Add(answerField);
            i++;
        }
        Lucene.Net.Documents.Field QueryTypeField = new Field("query_type", root.query_type, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES);
        Lucene.Net.Documents.Field QueryField = new Field("query", root.query, Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.YES);
        doc.Add(QueryTypeField);
        doc.Add(QueryField);
        writer.AddDocument(doc);*/
    }


    /// <summary>
    /// Flushes the buffer and closes the index
    /// </summary>
    public void CleanUpIndexer()
    {
        writer.Optimize();
        writer.Flush(true, true, true);
        writer.Dispose();
    }
    

    /// <summary>
    /// Creates the searcher object
    /// </summary>
    public void CreateSearcher()
    {
        searcher = new IndexSearcher(luceneIndexDirectory,true);
    }

    /// <summary>
    /// Creates the parser object
    /// </summary>
    public void CreateParser(string field)
    {
        parser = new QueryParser(VERSION, field, analyzer);
    }

    public Query ParseQuery(string querytext)
    {
        Query query = parser.Parse(querytext.ToLower());
        return query;
    }

    /// <summary>
    /// Searches the index for the querytext
    /// </summary>
    /// <param name="querytext">The text to search the index</param>
    public TopDocs SearchText(Query query)
    {      
        TopDocs results = searcher.Search(query, 10);
        return results;
    }


    /// <summary>
    /// Displays a ranked list of results to the screen
    /// </summary>
    /// <param name="results">A set of results</param>
    public List<string []> DisplayResults(TopDocs results)
    {
        List<string []> resultList = new List<string []>();

        int rank = 0;
        foreach (ScoreDoc scoreDoc in results.ScoreDocs)
        {
            rank++;
            string[] docResult = new string[5];
            docResult[0] = rank.ToString();
            Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
            int fieldNum = 0;
            foreach (string field in FIELDS_FN)
            {
                fieldNum++;
                docResult[fieldNum] = doc.Get(FIELDS_FN[fieldNum-1]).ToString();
            }
            resultList.Add(docResult);
                          
            
        }

        return resultList;

    }


    /// <summary>
    /// Closes the index after searching
    /// </summary>
    public void CleanUpSearcher()
    {
        searcher.Dispose();
    }

    public bool isIndexAvailale()
    {
        return (luceneIndexDirectory == null) ? false : true;
    }
}