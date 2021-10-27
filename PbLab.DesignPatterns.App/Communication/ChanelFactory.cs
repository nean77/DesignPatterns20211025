namespace PbLab.DesignPatterns.Communication
{
    public class ChanelFactory : IChanelFactory
    {
        public IChanel Create(string protocol)
        {
            IChanel result = null;

            switch (protocol)
            {
                case "file": result = new FileChanel(); break;
                case "http": result = new HttpChanel(); break;
            }

            return result;
        }
    }
}
