using BussinessLayer.Contracts;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
	// This logic is used to take the photo from the admin
	public class FileServices : IFileServices
	{
		public string UploadFile (IFormFile file , string destination)
		{
			var fileName = string.Empty;
			if (file != null && file.Length > 0)
			{
				var UplaodingFolder = Path.Combine(@"./wwwroot/",destination);
				fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
				var UploadedFilePath = Path.Combine(UplaodingFolder, fileName);

				using (var fileStream = new FileStream(UploadedFilePath, FileMode.Create))
				{
					file.CopyTo(fileStream);
				}
			}
			return fileName;
		}
	}
}
