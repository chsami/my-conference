using ConferenceApi.Models;
using ConferenceApi.Queries;
using ConferenceApi.Store;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConferenceApi.Controllers
{
    [Route("/graphql")]
    public class GraphQlController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        private readonly IDataLoaderContextAccessor _accessor;
        private readonly IDatastore _dataStore;


        public GraphQlController(ISchema schema, IDocumentExecuter documentExecuter, IDataLoaderContextAccessor accessor, IDatastore dataStore)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
            _accessor = accessor;
            _dataStore = dataStore;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = _schema;
                x.Query = query.Query;
                x.Inputs = query.Variables;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
