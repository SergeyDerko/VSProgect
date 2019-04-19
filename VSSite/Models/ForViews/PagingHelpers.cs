using System;
using System.Text;
using System.Web.Mvc;

namespace VSSite.Models.ForViews
{
    /// <summary>
    /// Класс для своих хелперов :)
    /// </summary>
    public static class PagingHelpers
    {
        /// <summary>
        /// HTML хелпер, для пейждинга 
        /// </summary>
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            TagBuilder tagFirst = new TagBuilder("a");
            tagFirst.MergeAttribute("onclick", "selestPage(1)");
            tagFirst.MergeAttribute("title", "start page");
            tagFirst.InnerHtml =
                "<img class='pagination__img' src='/Content/img/gear-wheel.png' alt='gear-wheel.png'><img class='pagination__pade-arrow' src='/Content/img/arrow-backward.png' alt='arrow-backward.png'>";

            tagFirst.AddCssClass("pagination__link");
            result.Append(tagFirst);
            int count = 0;

            for (int i = pageInfo.PageNumber - 6 > 0 ? pageInfo.PageNumber - 5 : 1; i <= pageInfo.TotalPages; i++)
            {
                if (count != 10)
                {
                    count++;
                    TagBuilder tag = new TagBuilder("a");
                    tag.MergeAttribute("onclick", $"selestPage({i})");
                    tag.MergeAttribute("title", "page - " + i);
                    tag.InnerHtml = "<img class='pagination__img' src='/Content/img/gear-wheel.png' alt='gear-wheel.png'><span class='pagination__pade-number'>"+i+"</span>";
                    if (i == pageInfo.PageNumber)
                    {
                        tag.AddCssClass("selected");
                    }
                    tag.AddCssClass("pagination__link");
                    result.Append(tag);
                }

            }
            TagBuilder tagLast = new TagBuilder("a");

            tagLast.MergeAttribute("onclick", $"selestPage({pageInfo.TotalPages})");
            tagLast.MergeAttribute("title", "last page");
            tagLast.InnerHtml = "<img class='pagination__img' src='/Content/img/gear-wheel.png' alt='gear-wheel.png'><img class='pagination__pade-arrow' src='/Content/img/arrow-forward.png' alt='arrow-forward.png'>"; 
            tagLast.AddCssClass("pagination__link");
            result.Append(tagLast);

            return MvcHtmlString.Create(result.ToString());
        }
        //<div class="pagination">
        //   @Html.PageLinks(Model.PageInfo, x => Url.Action("Selling", new { page = x })) пример использования хелпера
        //</div>
    }
}