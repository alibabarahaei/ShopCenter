namespace ShopCenter.Application.InterfaceServices
{
    public interface IErrorService<TError>
    {
        public void ErrorHanling(List<TError> errors);
    }
}
