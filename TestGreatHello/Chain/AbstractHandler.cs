namespace TestGreatHello.Chain
{
    public abstract class AbstractHandler : IHandler
    {
        private IHandler _next;
        
        public IHandler SetNext(IHandler handler)
        {
            _next = handler;
            return handler;
        }

        public virtual string Handler(params string[] input)
        {
            if (_next != null)
                return _next.Handler(input);

            return null;
        }

    }
}
