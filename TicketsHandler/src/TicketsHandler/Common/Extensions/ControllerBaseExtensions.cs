using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using TicketsHandler.Data.Common;

namespace TicketsHandler.Common.Extensions
{
    public static class ControllerBaseExtensions
    {
        #region Public Methods

        public static ActionResult FromResult<T>(this ControllerBase controller, CommandResult<T> commandResult)
        {
            switch (commandResult.ResultType)
            {
                case ResultType.Ok:
                    return controller.Ok(commandResult.Data);
                case ResultType.NotFound:
                    return GetErrorObjectResult(controller, StatusCodes.Status404NotFound, commandResult.Errors);
                case ResultType.Unexpected:
                    return GetErrorObjectResult(controller, StatusCodes.Status500InternalServerError,
                        commandResult.Errors);
                default:
                    throw new ArgumentOutOfRangeException(nameof(commandResult.ResultType));
            }
        }

        #endregion

        #region Private Methods

        private static ObjectResult GetErrorObjectResult(this ControllerBase controller, int httpStatusCode,
            List<string> errors)
        {
            var errorString = string.Join(",", errors);
            return controller.Problem(errorString, statusCode: httpStatusCode, title: ReasonPhrases.GetReasonPhrase(httpStatusCode));
        }

        #endregion
    }
}
