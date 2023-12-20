using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using HC.Application.Common.Exceptions;
using HC.Application.Common.Interfaces;
using HC.Domain.Common;
using HC.Domain.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HC.Application.Services
{
    public class StorageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StorageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> UploadFile(StorageRequest request)
        {
            try
            {
                //handle upload file
                var creadentials = new BasicAWSCredentials(AppConfig.AwsCredentials.AccessKey, AppConfig.AwsCredentials.SecretKey);
                var config = new AmazonS3Config()
                {
                    RegionEndpoint = Amazon.RegionEndpoint.APSoutheast1
                };

                var uploadRequest = new TransferUtilityUploadRequest()
                {
                    //upload to /foleName
                    InputStream = request.File.OpenReadStream(),
                    Key = Guid.NewGuid().ToString(),
                    BucketName = AppConfig.AwsCredentials.BucketName,
                    CannedACL = S3CannedACL.PublicRead
                };

                using var client = new AmazonS3Client(creadentials, config);
                // initialise the transfer/upload tools
                var transferUtility = new TransferUtility(client);

                // initiate the file upload
                await transferUtility.UploadAsync(uploadRequest).ConfigureAwait(false);

                var url = $"{AppConfig.AwsCredentials.BucketName}/{uploadRequest.Key}";

                return url;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
