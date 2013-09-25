namespace Domas.Web.Mvc.UI
{
    using System;
    using System.Linq.Expressions;
    using Domas.Web.Mvc.Extensions;
    using System.Collections;

    public class ChartCandlestickSeries<TModel, TValue, TCategory> : ChartOHLCSeries<TModel, TValue, TCategory>, IChartCandlestickSeries where TModel : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartCandlestickSeries{TModel, TValue}" /> class.
        /// </summary>
        /// <param name="openExpression">The open expression.</param>
        /// <param name="highExpression">The high expression.</param>
        /// <param name="lowExpression">The low expression.</param>
        /// <param name="closeExpression">The close expression.</param>
        /// <param name="colorExpression">The color expression.</param>
        /// <param name="downColorExpression">The down color expression.</param>
        /// <param name="categoryExpression">The expression used to extract the point category from the chart model.</param>
        /// <param name="categoryExpression">The expression used to extract the point category from the chart model.</param>
        /// <param name="noteTextExpression">The down color expression.</param>
        public ChartCandlestickSeries(
            Expression<Func<TModel, TValue>> openExpression,
            Expression<Func<TModel, TValue>> highExpression,
            Expression<Func<TModel, TValue>> lowExpression,
            Expression<Func<TModel, TValue>> closeExpression,
            Expression<Func<TModel, string>> colorExpression,
            Expression<Func<TModel, string>> downColorExpression,
            Expression<Func<TModel, TCategory>> categoryExpression,
            Expression<Func<TModel, string>> noteTextExpression
            )
            : base(openExpression, highExpression, lowExpression, closeExpression, colorExpression, categoryExpression, noteTextExpression)
        {
            if (downColorExpression != null)
            {
                DownColorMember = downColorExpression.MemberWithoutInstance();
            }

            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartCandlestickSeries{TModel, TValue}" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public ChartCandlestickSeries(IEnumerable data)
            : base()
        {
            Data = data;
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartCandlestickSeries{TModel, TValue}" /> class.
        /// </summary>
        public ChartCandlestickSeries()
            : base()
        {
            Initialize();
        }

        /// <summary>
        /// Gets the model data down color member name.
        /// </summary>
        /// <value>The model data down color member name.</value>
        public string DownColorMember { get; set; }

        /// <summary>
        /// Gets or sets the effects overlay
        /// </summary>
        public ChartBarSeriesOverlay Overlay { get; set; }

        private void Initialize()
        {
            Type = "candlestick";
        }

        public override IChartSerializer CreateSerializer()
        {
            return new ChartCandlestickSeriesSerializer(this);
        }
    }
}