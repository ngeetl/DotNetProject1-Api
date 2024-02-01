using Microsoft.AspNetCore.Mvc;

namespace DotNetProject.Api.Controllers
{
    [ApiController] // 요청 데이터의 유효성을 자동으로 검사함
	[Route("[controller]")] // [controller]는 컨트롤러의 이름으로 대체됨
	public class TopicController : ControllerBase
	{
		private static readonly string[] Topics = new[]
		{
			"음식", "직장", "외출", "친구", "감정", "미디어", "꿈", "어제", "10년후", "버킷리스트", "부모님", "사랑", "반려동물", "돈", "지출"
		};

		private readonly ILogger<TopicController> _logger;

		public TopicController(ILogger<TopicController> logger)
		{
			_logger = logger;
		}

		[HttpGet(Name = "GetTopics")]
		public string[] GetRandomTopics()
		{
			Random rnd = new Random();
			var selectedTopics = new string[4];

			for (int i = 0; i < 4; i++)
			{
				int index = rnd.Next(Topics.Length);
				// 중복 방지를 위해 선택된 요소가 이미 배열에 있는지 확인
				while (Array.IndexOf(selectedTopics, Topics[index]) != -1)
				{
					index = rnd.Next(Topics.Length);
				}
				selectedTopics[i] = Topics[index];
			}

			return selectedTopics.ToArray();
		}


		//[HttpPost]
		//public WeatherForecastModel Post()
		//{
		//	return new WeatherForecastModel() { Date = DateTime.Now };
		//}

		//[HttpPut]
		//public IActionResult Put()
		//{
		//	return Ok();

		//[HttpDelete]
		//public IActionResult Delete()
		//{
		//	return Ok();
		//}


	}
}
