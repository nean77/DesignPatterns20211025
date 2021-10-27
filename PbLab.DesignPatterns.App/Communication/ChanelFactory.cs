namespace PbLab.DesignPatterns.Communication
{
    public class ChanelFactory : IChanelFactory
    {
        public IChanel Create(string protocol)
        {
            protocol = protocol ?? string.Empty; 

            IChanel result = new NullChanel();

            switch (protocol)
            {
                case "file": result = new FileChanel(); break;
                case "http": result = new HttpChanel(); break;
            }

            return result;
        }
    }
}
