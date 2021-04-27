namespace WebApi.Controllers.Errors.ErrorOrderBuild
{
    public class ErrorBuildParam
    {
        public int? IdComputer { get; internal set; }
        public int? IdComponent { get; internal set; }
        public string Commentary { get; internal set; }
        public bool DeleteComponent { get; internal set; }
    }
}