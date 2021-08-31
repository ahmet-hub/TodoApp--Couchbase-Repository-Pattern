namespace TodoApp.Dal
{
    public class CouchbaseSettings
    {
        public string Endpoint { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Bucket { get; set; }
        public string Scope { get; set; }
    }
}