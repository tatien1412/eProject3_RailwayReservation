import { Component, OnInit } from '@angular/core';
import {
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexYAxis,
  ApexTitleSubtitle,
  ApexLegend,
  ApexPlotOptions,
  NgApexchartsModule
} from 'ng-apexcharts';

import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-total-revenue-chart',
  standalone : true,
  imports:[NgApexchartsModule,CommonModule],
  templateUrl: './total-revenue-chart.component.html',
  styleUrls: ['./total-revenue-chart.component.css']
})
export class TotalRevenueChartComponent implements OnInit {
  public series: ApexAxisChartSeries;
  public chart: ApexChart;
  public xaxis: ApexXAxis;
  public dataLabels: ApexDataLabels;
  public yaxis: ApexYAxis;
  public title: ApexTitleSubtitle;
  public legend: ApexLegend;
  public plotOptions: ApexPlotOptions;

  public currentYear: number;

  constructor() {
    this.series = [];
    this.plotOptions={
      bar: {
        borderRadius: 10, // Đặt border radius cho các cột
        horizontal: false
      }
    };
    this.currentYear = 2023; // Năm mặc định ban đầu
    this.updateChartData();
    
    this.chart = {
      type: 'bar',
      height: 350
    };
    this.xaxis = {
      categories: ['Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa', 'Su']
    };

    this.dataLabels = {
      enabled: false
    };

    this.yaxis = {
      min: 0,
      max: 100
    };

    this.title = {
      text: 'Total Revenue',
      align: 'left'
    };

    this.legend = {
      position: 'top',
      horizontalAlign: 'left'
    };
  }
  ngOnInit(): void {}
  updateChartData(): void {
    if (this.currentYear === 2023) {
      this.series = [
        {
          name: '2023',
          data: [10, 20, 15, 30, 25, 20, 10] // Dữ liệu của 2023
        }
      ];
    } else if (this.currentYear === 2022) {
      this.series = [
        {
          name: '2022',
          data: [-10, -15, -5, -10, -5, -15, -10] // Dữ liệu của 2022
        }
      ];
    }
  }
  setYear(year: number): void {
    this.currentYear = year;
    this.updateChartData();
  }
}
