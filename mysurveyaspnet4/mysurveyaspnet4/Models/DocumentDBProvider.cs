using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace mysurveyaspnet4.Models
{
    public class DocumentDbProvider
    {
        private DocumentClient client;
        private Database database;
        private DocumentCollection documentCollection;
        public DocumentDbProvider(string endPointUrl, string authorizationKey)
        {
            // Create a new instance of the DocumentClient
            client = new DocumentClient(new Uri(endPointUrl), authorizationKey);
        }

        public async Task InitializeDatabase()
        {
            await CreateDatabase();

            await CreateAnswersCollection();
        }

        public async Task InsertSurvey(SurveyAnswer survey)
        {
            Document document = client.CreateDocumentQuery("dbs/" + database.Id + "/colls/" + documentCollection.Id)
                                .Where(d => d.Id == survey.SurveyId).AsEnumerable().FirstOrDefault();

            // id based routing for the first argument, "dbs/FamilyRegistry/colls/FamilyCollection"
            await client.CreateDocumentAsync("dbs/" + database.Id + "/colls/" + documentCollection.Id, survey);
        }




        private async Task CreateAnswersCollection()
        {
            // Check to verify a document collection with the id=FamilyCollection does not exist
            documentCollection = client.CreateDocumentCollectionQuery("dbs/" + database.Id)
                                            .Where(c => c.Id == "AnswersCollection").AsEnumerable().FirstOrDefault();

            // If the document collection does not exist, create a new collection
            if (documentCollection == null)
            {
                documentCollection = await client.CreateDocumentCollectionAsync("dbs/" + database.Id,
                    new DocumentCollection
                    {
                        Id = "AnswersCollection"
                    });

            }
        }

        private async Task CreateDatabase()
        {
            // Check to verify a database with the id=FamilyRegistry does not exist
            database = this.client.CreateDatabaseQuery().Where(db => db.Id == "Survey").AsEnumerable().FirstOrDefault();

            // If the database does not exist, create a new database
            if (database == null)
            {
                database = await client.CreateDatabaseAsync(
                    new Database
                    {
                        Id = "Survey"
                    });
            }
        }
    }

    
}