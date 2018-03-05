using Library.Domain.Contracts;
using Library.Domain.Dto;
using System;
using System.Net;
using System.Web.Http;

namespace Library.Api.Controllers
{
    [RoutePrefix("api/books")]
    public class BookController : ApiController
    {
        public BookController(IBookService service)
        {
            _service = service;
        }

        protected readonly IBookService _service;

        [HttpGet]
        [Route("{id:long}")]
        public IHttpActionResult GetById(long id)
        {
            var result = _service.GetById(id);
            switch ((int)result.Item1)
            {
                case (int)HttpStatusCode.OK:
                    return Ok(result.Item3);
                case (int)HttpStatusCode.NotFound:
                    return NotFound ();
                default:
                    return InternalServerError(new Exception(result.Item2));
            }
        }

        [HttpGet]
        [Route("page/{page:int}")]
        public IHttpActionResult GetPaginated(int page = 0)
        {
            var result = _service.GetPaginated(page);
            switch ((int)result.Item1)
            {
                case (int)HttpStatusCode.OK:
                    return Ok(result.Item3);
                default:
                    return InternalServerError(new Exception(result.Item2));
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(BookModel model)
        {
            var result = _service.Create(model);
            switch ((int)result.Item1)
            {
                case (int)HttpStatusCode.OK:
                    return Ok(result.Item2);
                case (int)HttpStatusCode.Created:
                    return Created(result.Item2, result.Item3);
                default:
                    return InternalServerError(new Exception(result.Item2));
            }
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Update(BookModel model)
        {
            var result = _service.Update(model);
            switch ((int)result.Item1)
            {
                case (int)HttpStatusCode.OK:
                    return Ok(result.Item2);
                default:
                    return InternalServerError(new Exception(result.Item2));
            }
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IHttpActionResult Delete(long id)
        {
            var result = _service.Delete(id);
            switch ((int)result.Item1)
            {
                case (int)HttpStatusCode.OK:
                    return Ok(result.Item2);
                default:
                    return InternalServerError(new Exception(result.Item2));
            }
        }
    }
}