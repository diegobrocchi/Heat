namespace Heat
{
    public interface IValidator
	{
		bool IsValid { get; }
		string ErrorMessage { get; }
	}
}
