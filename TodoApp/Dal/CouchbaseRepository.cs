using Couchbase;
using Couchbase.KeyValue;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Dal
{
    public class CouchbaseRepository<T> : IRepository<T>
     where T : DomainAggregate
    {
        private readonly string collectionName;
        private readonly CouchbaseSettings _couchbaseSettings;
        private ICluster cluster;
        private IBucket bucket;
        private IScope scope;
        private ICouchbaseCollection collection;

        public CouchbaseRepository(CouchbaseSettings couchbaseSettings)
        {
            _couchbaseSettings = couchbaseSettings;
            Task.Run(async () => await CreateConnection()).Wait();
        }
        private async Task CreateConnection()
        {
            cluster = await Cluster.ConnectAsync(_couchbaseSettings.Endpoint, _couchbaseSettings.User, _couchbaseSettings.Password);
            bucket = await cluster.BucketAsync(_couchbaseSettings.Bucket);
            scope = await bucket.ScopeAsync(_couchbaseSettings.Scope);
            collection = await scope.CollectionAsync(typeof(T).Name.ToLower());
        }

        public Task<Response<IEnumerable<T>>> GetAllAsync()
        {
            return null;
        }
        public async Task<Response<T>> GetAsync(string id)
        {
            try
            {
                var result = await collection.GetAsync(id);
                var data = result.ContentAs<T>();
                return Response.Ok<T>("Success", data);
            }
            catch (Exception ex)
            {

                return Response.Fail<T>(ex.Message);
            }
        }

        public Task<Response<IEnumerable<T>>> QueryAsync(Expression<Func<T, bool>> predicate = null)
        {
            //var result = await collection.
            return null;
        }
        public async Task<Response<T>> CreateAsync(T data)
        {
            try
            {
                var result = await collection.InsertAsync(data.Id, data);
                return Response.Ok("Success", data);
            }
            catch (Exception ex)
            {
                return Response.Fail<T>(ex.Message);
            }
        }

        public async Task<Response<T>> DeleteAsync(string id)
        {
            try
            {
                await collection.RemoveAsync(id);
                return Response.Ok<T>("Success");
            }
            catch (Exception ex)
            {
                return Response.Fail<T>(ex.Message);
            }
        }

        public async Task<Response<T>> UpdateAsync(T data)
        {
            try
            {
                await collection.ReplaceAsync(data.Id, data);
                return Response.Ok<T>("Success");
            }
            catch (Exception ex)
            {

                return Response.Fail<T>(ex.Message);
            }
        }

        public async Task<Response<T>> AddTask()
        {
          
        }



        //public async Task<Response<T>> ReadAsync(Guid id)
        //{
        //    var result = await collection.GetAsync(id.ToString());
        //    return result.ContentAs<dynamic>();
        //}

        //public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate)
        //{
        //    // var results = new List<T>();
        //    //
        //    // var query = client.CreateDocumentQuery<T>(
        //    //     UriFactory.CreateDocumentCollectionUri(
        //    //         databaseId,
        //    //         collectionId),
        //    //     new FeedOptions
        //    //     {
        //    //         MaxItemCount = -1,
        //    //         EnableCrossPartitionQuery = true
        //    //     });
        //    //
        //    // predicate = null;
        //    // var conditionalQuery = predicate == null
        //    //     ? query
        //    //     : query.Where(predicate);
        //    //
        //    // var documentQuery = conditionalQuery.AsDocumentQuery();
        //    //
        //    // while (documentQuery.HasMoreResults)
        //    // {
        //    //     results.AddRange(await documentQuery.ExecuteNextAsync<T>());
        //    // }
        //    //
        //    // return results;

        //    return null;
        //}

        //public async Task<IEnumerable<T>> AllAsync()
        //{
        //    //using (var cluseter = new Cluster())
        //    //{

        //    //}
        //    return null;
        //}

        //public async Task<T> CreateAsync(T item)
        //{
        //    var result = await collection.InsertAsync(item.Id.ToString(), item);
        //    return item;
        //}
        //public async Task UpdateAsync(T item)
        //{
        //    var result = await bucket.Collection(collectionName).ReplaceAsync(item.Id, item);
        //}
        //public async Task DeleteAsync(string id)
        //{
        //    await bucket.Collection(collectionName).RemoveAsync(id);
        //}
    }
}
