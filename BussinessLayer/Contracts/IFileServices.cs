using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Contracts
{
	public interface IFileServices
	{
		string UploadFile(IFormFile file, string destination);
	}
}
