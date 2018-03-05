namespace Library.Domain.Enum
{
    /// <summary>
    /// Represents the HTTP status code.
    /// </summary>
    public enum StatusCode
    {
        /// <summary>
        /// The request has succeeded.
        /// </summary>
        Ok = 200,
        /// <summary>
        /// The request has been fulfilled and resulted in a new resource being created.
        /// </summary>
        Created = 201,
        /// <summary>
        /// The server has not found anything matching the Request-URI.
        /// </summary>
        NotFound = 404,
        /// <summary>
        /// The server encountered an unexpected condition which prevented it from fulfilling the request.
        /// </summary>
        InternalServerError = 500
    }
}
