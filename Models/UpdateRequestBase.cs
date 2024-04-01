namespace WebApi.Models
{
	public class UpdateRequestBase
	{
		// helpers
		protected string? replaceEmptyWithNull(string? value)
		{
			// replace empty string with null to make field optional
			return string.IsNullOrEmpty(value) ? null : value;
		}
	}
}
