namespace AutoVin_Code_Challenge.Shared.DTO.Response
{
    public class ResponseHeader
    {
        /// <summary>
        /// True or False whether operation is successful or not
        /// </summary>
        public bool Success { get; set; } = false;
        /// <summary>
        /// Message from operation response
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Operation response code
        /// </summary>
        public int StatusCode { get; set; }
    }
}
