using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Models
{
    internal class CustomProblemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}