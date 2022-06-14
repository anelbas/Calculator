using System.Text.Json;

namespace CalculatorAPI.Repository
{
    [Serializable]
    public class ErrorException:Exception
    {
        
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ErrorException(int StatusCode, String Message){
            this.StatusCode = StatusCode;
            this.Message = Message;
        }
        public string ToString()
        {
            return "StutusCode: "+StatusCode+"\n"+"Message: "+Message;
        }
    }
}