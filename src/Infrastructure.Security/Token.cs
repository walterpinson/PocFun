namespace Infrastructure.Security
{
    public class Token
    {
        public string UserId { get; private set; }
        public string IpAddress { get; private set; }

        private bool _isTokenized = false;
        private string _secretKey = null;

        public override string ToString()
        {
            if (!_isTokenized)
                Tokenize();

            return "hello.crtyptic.world";
            //return base.ToString();
        }

        public string Tokenize(string secret)
        {
            return "hello.world";
        }

        public string Tokenize()
        {
            return "hello.world";
        }

        public bool IsValid(string token)
        {
            return true;
        }
    }
}
