using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using HC.Application.Common.Exceptions;
using HC.Domain.Dto.Requests;
using Microsoft.Extensions.Options;

namespace HC.Infrastructure.Storage;

public class StorageService
{
    private readonly AwsSettings _awsSettings;

    public StorageService(IOptions<AwsSettings> awsSettings)
    {
        _awsSettings = awsSettings.Value;
    }
    public async Task<string> UploadFile(StorageRequest request)
    {
        try
        {
            //handle upload file
            var creadentials = new BasicAWSCredentials(_awsSettings.AccessKey, _awsSettings.SecretKey);
            var config = new AmazonS3Config()
            {
                RegionEndpoint = Amazon.RegionEndpoint.APSoutheast1
            };

            var uploadRequest = new TransferUtilityUploadRequest()
            {
                //upload to /foleName
                InputStream = request.File.OpenReadStream(),
                Key = Guid.NewGuid().ToString(),
                BucketName = _awsSettings.BucketName,
                CannedACL = S3CannedACL.PublicRead
            };

            using var client = new AmazonS3Client(creadentials, config);
            // initialise the transfer/upload tools
            var transferUtility = new TransferUtility(client);

            // initiate the file upload
            await transferUtility.UploadAsync(uploadRequest).ConfigureAwait(false);

            var url = $"{_awsSettings.BucketName}/{uploadRequest.Key}";

            return url;
        }
        catch (Exception ex)
        {
            throw new BadRequestException(ex.Message);
        }
    }
}