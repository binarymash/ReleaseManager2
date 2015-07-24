using WebApi.Hal;

namespace ReleaseManager.Api.Host.VndError
{
    // See https://github.com/blongden/vnd.error
    public class Error : Representation
    {
        public string LogRef { get; set; }

        public string Message { get; set; }

        protected override void CreateHypermedia()
        {
            base.CreateHypermedia();
        }
    }
}
