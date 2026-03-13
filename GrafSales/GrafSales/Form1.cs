using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using GrafSales.Model;
using LiveCharts.Definitions.Charts;

namespace SportsApp
{
    public partial class Form1 : Form
    {
        private SportsData sportsData;

        public Form1()
        {
            InitializeComponent();
            sportsData = new SportsData();
            LoadSections();
        }

        private void LoadSections()
        {
            listBoxSections.DisplayMember = "Name";
            listBoxSections.ValueMember = "Id";
            listBoxSections.DataSource = sportsData.Sections;
        }

        private void listBoxSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxSections.SelectedItem is Section selectedSection)
            {
                ShowSectionVisits(selectedSection);
                ShowRevenueDistribution();
                UpdateTotalRevenue();
            }
        }

        private void ShowSectionVisits(Section section)
        {
            var visits = sportsData.GetVisitsForSection(section.Id);

            // Группируем посещения по дням
            var visitsByDay = visits
                .GroupBy(v => v.Date.Date)
                .Select(g => new { Date = g.Key, TotalVisitors = g.Sum(v => v.VisitorCount) })
                .OrderBy(x => x.Date)
                .ToList();

            // Создаем коллекцию для графика
            var chartValues = new ChartValues<int>();
            var labels = new List<string>();

            foreach (var dayVisit in visitsByDay)
            {
                chartValues.Add(dayVisit.TotalVisitors);
                labels.Add(dayVisit.Date.ToString("dd.MM"));
            }

            // Настройка графика
            cartesianChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = section.Name,
                    Values = chartValues,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10
                }
            };

            cartesianChart.AxisX.Clear();
            cartesianChart.AxisX.Add(new Axis
            {
                Title = "Дата",
                Labels = labels
            });

            cartesianChart.AxisY.Clear();
            cartesianChart.AxisY.Add(new Axis
            {
                Title = "Количество посещений",
                LabelFormatter = value => value.ToString("N0")
            });

            cartesianChart.LegendLocation = LegendLocation.Top;
        }

        private void ShowRevenueDistribution()
        {
            var revenue = sportsData.GetRevenueBySection();
            decimal totalRevenue = revenue.Sum(x => x.Value);

            var seriesCollection = new SeriesCollection();

            foreach (var item in revenue)
            {
                if (item.Value > 0)
                {
                    double percentage = (double)(item.Value / totalRevenue * 100);

                    seriesCollection.Add(new PieSeries
                    {
                        Title = $"{item.Key} ({percentage:F1}%)",
                        Values = new ChartValues<decimal> { item.Value },
                        DataLabels = true,
                        LabelPoint = chartPoint =>
                            $"{chartPoint.SeriesView.Title}: {chartPoint.Y:F0} руб."
                    });
                }
            }

            pieChart.Series = seriesCollection;
            pieChart.LegendLocation = LegendLocation.Right;
        }

        private void UpdateTotalRevenue()
        {
            var revenue = sportsData.GetRevenueBySection();
            decimal totalRevenue = revenue.Sum(x => x.Value);

            labelRevenue.Text = $"Общий доход спортивного центра: {totalRevenue:C}";
        }

        private void InitializeComponent()
        {
            this.pieChart = new LiveCharts.WinForms.PieChart();
            this.cartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.listBoxSections = new System.Windows.Forms.ListBox();
            this.labelRevenue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pieChart
            // 
            this.pieChart.Location = new System.Drawing.Point(12, 266);
            this.pieChart.Name = "pieChart";
            this.pieChart.Size = new System.Drawing.Size(226, 176);
            this.pieChart.TabIndex = 0;
            this.pieChart.Text = "pieChart";
            // 
            // cartesianChart
            // 
            this.cartesianChart.Location = new System.Drawing.Point(265, 12);
            this.cartesianChart.Name = "cartesianChart";
            this.cartesianChart.Size = new System.Drawing.Size(322, 415);
            this.cartesianChart.TabIndex = 1;
            this.cartesianChart.Text = "cartesianChart3";
            // 
            // listBoxSections
            // 
            this.listBoxSections.FormattingEnabled = true;
            this.listBoxSections.Location = new System.Drawing.Point(12, 12);
            this.listBoxSections.Name = "listBoxSections";
            this.listBoxSections.Size = new System.Drawing.Size(226, 212);
            this.listBoxSections.TabIndex = 2;
            this.listBoxSections.SelectedIndexChanged += new System.EventHandler(this.listBoxSections_SelectedIndexChanged);
            // 
            // labelRevenue
            // 
            this.labelRevenue.AutoSize = true;
            this.labelRevenue.Location = new System.Drawing.Point(12, 236);
            this.labelRevenue.Name = "labelRevenue";
            this.labelRevenue.Size = new System.Drawing.Size(9, 13);
            this.labelRevenue.TabIndex = 3;
            this.labelRevenue.Text = "l";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(599, 454);
            this.Controls.Add(this.labelRevenue);
            this.Controls.Add(this.listBoxSections);
            this.Controls.Add(this.cartesianChart);
            this.Controls.Add(this.pieChart);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}