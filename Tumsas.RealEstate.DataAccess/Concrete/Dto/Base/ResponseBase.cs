namespace Tumsas.RealEstate.DataAccess.Concrete.Dto.Base
{
    public class ResponseBase<T>
    {
        public ResponseBase(T data)
        {
            Data = data;
        }

        public string Message { get; set; }

        public bool Success { get; set; } = true;

        public T Data { get; set; }
    }
}