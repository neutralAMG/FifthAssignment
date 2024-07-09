

namespace FifthAssignment.Core.Application.Core
{
	public class Result<TData>
	{
        public Result()
        {
            IsSuccess = true;
        }
        public bool IsSuccess { get; set; }

		public string? Message { get; set; }

		public TData? Data { get; set; }
	}
}
