using System.Collections.Generic;
using RPFramework.Models.api.DashboardRelated;
using RPFramework.Models.api.WigdetRelated;
using WidgetOptions = RPFramework.Models.api.WigdetRelated.WidgetOptions;

namespace RPFramework.Core
{
    public static class ApiModelsFactory
    {
        public static Dashboard GetPredefinedDashboard() => new Dashboard()
        {
            Description = "string",
            Name = "string",
            Share = true
        };
        
        public static Widget GetPredefinedWidget(string name = "TestNewWidget", string widgetType = "casesTrend")
        {
            return new Widget()
            {
                description = $"{name} Description",
                owner = "default",
                share = true,
                id = 133,
                name = name,
                widgetType = widgetType,
                contentParameters = new ContentParameters()
                {
                    contentFields = new List<string>()
                    {
                        "statistics$executions$total",
                    },
                    itemsCount = 50,
                    widgetOptions = new WidgetOptions()
                    {
                        timeline = "launch",
                    }
                },
                appliedFilters = new List<AppliedFilter>()
                {
                    new AppliedFilter()
                    {
                        owner = "default",
                        share = true,
                        id = 16,
                        name = "DEMO_FILTER",
                        conditions = new List<Condition>()
                        {
                            new Condition()
                            {
                                filteringField = "compositeAttribute",
                                condition = "has",
                                value = "demo",
                            }
                        },
                        orders =new List<Order>()
                        {
                            new Order()
                            {
                                sortingColumn = "startTime",
                                isAsc = false,
                            }
                        },
                        type = "Launch",
                    }
                },
                content = new Content()
                {
                    result = new List<Result>()
                    {
                        new Result()
                        {
                            id = 6,
                            number = 1,
                            name = "Demo Api Tests",
                            startTime = 1663004819805,
                            values = new Values()
                            {
                                StatisticsExecutionsTotal = "10",
                                delta = "0",
                            }
                        }
                    }
                }
            };
        }
    }
}