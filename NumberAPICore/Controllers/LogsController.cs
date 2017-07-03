using FileIO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace NumberAPICore.Controllers
{
    [Produces("application/json")]
    [Route("api/Logs")]
    public class LogsController : Controller
    {
        private IHostingEnvironment _env;
        private readonly string webRoot;
        private readonly IOOperation ios;
        public LogsController(IHostingEnvironment env, IOOperation iosin)
        {
            _env = env;
            webRoot = _env.WebRootPath;
            this.ios = iosin;
        }
        [Route("getfile")]
        //read a full file at a time is not ideal it could be very large
        // in this case just to demostrate 
        public JsonResult GetFile()
        {
            //file path hard coded for the time being 
            var file = System.IO.Path.Combine(webRoot, @"LogsFiles\Logs\numbers-20170702.txt");
            return Json(ios.GetFile(file));
        }
        [Route("getfile/{nlines?}")]
        // this action methods would help to read last N lines 
        //in same directory multiple files could be present but 
        //that are not considering here due to time shortage
        public JsonResult GetLastNLinesFromFile(int nlines = 100)
        {
            //file path hard coded for the time being 
            var file = System.IO.Path.Combine(webRoot, @"LogsFiles\Logs\numbers-20170702.txt");
            return Json(ios.GetFile(file, nlines));
        }
    }
}