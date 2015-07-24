using System.Collections.Generic;
using WebApi.Hal;

namespace ReleaseManager.Api.Host.VndError
{
    // See https://github.com/blongden/vnd.error
    public class ErrorCollection : Representation
    {
        public int Total { get; set; }

        public IEnumerable<Error> Errors { get; set; }
    }
}
