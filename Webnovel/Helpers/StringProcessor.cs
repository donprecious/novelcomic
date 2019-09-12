using HtmlAgilityPack;

namespace Webnovel.Helpers
{
	public static class StringProcessor
	{
		public static string SubString(string value, int start, int stop)
		{
			if (value.Length > stop)
			{
				return value.Substring(start, stop) + " ...";
			}
			return value.Substring(start, value.Length);
		}

		public static int CountWordsWithoutHtml(string htmlString)
		{
			
			HtmlDocument val = (HtmlDocument)(object)new HtmlDocument();
			val.LoadHtml(htmlString);
            string innerText = val.DocumentNode.InnerText;
			innerText = innerText.Replace("&nbsp;", " ");
			int num = 0;
			int i;
			for (i = 0; i < innerText.Length && char.IsWhiteSpace(innerText[i]); i++)
			{
			}
			while (i < innerText.Length)
			{
				for (; i < innerText.Length && !char.IsWhiteSpace(innerText[i]); i++)
				{
				}
				num++;
				for (; i < innerText.Length && char.IsWhiteSpace(innerText[i]); i++)
				{
				}
			}
			return num;
		}
	}
}
