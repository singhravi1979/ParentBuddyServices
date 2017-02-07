using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;


namespace ParentBuddyService.DataContracts
{
	public class BaseResponsePresentationModel:IHttpActionResult
	{

		private dynamic _data;
		public BaseResponsePresentationModel(dynamic data)
		{
			_data = data;
		}
		protected virtual ObjectContent GetObjectContent()
		{
			return new ObjectContent(this.GetType(), this, new JsonMediaTypeFormatter());
		}

		public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{
			HttpResponseMessage response = null;

			if (_data != null)
			{
				response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
				response.Content = GetObjectContent();

			}
			else
				response = new HttpResponseMessage(System.Net.HttpStatusCode.NotFound);

			return Task.FromResult(response);
		}
	}
}
