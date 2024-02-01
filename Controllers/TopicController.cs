using Microsoft.AspNetCore.Mvc;

namespace DotNetProject.Api.Controllers
{
    [ApiController] // ��û �������� ��ȿ���� �ڵ����� �˻���
	[Route("[controller]")] // [controller]�� ��Ʈ�ѷ��� �̸����� ��ü��
	public class TopicController : ControllerBase
	{
		private static readonly string[] Topics = new[]
		{
			"����", "����", "����", "ģ��", "����", "�̵��", "��", "����", "10����", "��Ŷ����Ʈ", "�θ��", "���", "�ݷ�����", "��", "����"
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
				// �ߺ� ������ ���� ���õ� ��Ұ� �̹� �迭�� �ִ��� Ȯ��
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
