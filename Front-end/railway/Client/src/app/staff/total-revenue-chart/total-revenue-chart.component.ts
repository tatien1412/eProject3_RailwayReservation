import { Component, inject, OnInit } from '@angular/core';
import {
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexYAxis,
  ApexTitleSubtitle,
  ApexLegend,
  ApexStroke,
  ApexMarkers,
  NgApexchartsModule
} from 'ng-apexcharts';

import { CommonModule } from '@angular/common';
import { DailycashService } from '../../services/dailycash.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-total-revenue-chart',
  standalone: true,
  imports: [NgApexchartsModule, CommonModule, FormsModule],
  templateUrl: './total-revenue-chart.component.html',
  styleUrls: ['./total-revenue-chart.component.css']
})
export class TotalRevenueChartComponent implements OnInit {
  dailycashservice = inject(DailycashService);
  public series: ApexAxisChartSeries;
  public chart: ApexChart;
  public xaxis: ApexXAxis;
  public dataLabels: ApexDataLabels;
  public yaxis: ApexYAxis;
  public title: ApexTitleSubtitle;
  public legend: ApexLegend;
  public stroke: ApexStroke;
  public markers: ApexMarkers;

  public selectedDate: string = '';  // Ngày được người dùng chọn
  public currentYear: number = 0;
  public days: string[] = [];
  public revenues: number[] = [];
  public trends: number[] = [];

  constructor() {
    this.series = [
      {
        name: 'Doanh thu',
        type: 'column',
        data: []
      },
      {
        name: 'Xu hướng',
        type: 'line',
        data: []
      }
    ];

    this.chart = {
      type: 'line',
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
      max: 5000,
      labels: {
        formatter: function (value: number) {
          return value.toFixed(0);  // Hiển thị số nguyên, bỏ phần thập phân
        }
      }
    };

    this.title = {
      text: 'Total Revenue & Trend',
      align: 'left'
    };

    this.legend = {
      position: 'top',               // Đặt chú thích ở trên biểu đồ
      horizontalAlign: 'left',        // Căn lề trái cho chú thích
      labels: {
        colors: ['#fafafa', '#fafafa'], // Màu sắc của chữ "Doanh thu" (xanh dương) và "Xu hướng" (xanh lá)
        useSeriesColors: false         // Không sử dụng màu của series cho chữ
      },
      offsetY: -20,                    // Tạo khoảng cách giữa chú thích và biểu đồ
      fontSize: '14px',               // Tăng kích thước chữ nếu cần
    };
    

    this.stroke = {
      width: [0, 4],
      curve: 'smooth'
    };

    this.markers = {
      size: [0, 6]
    };

    this.days = ['Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa', 'Su'];
    this.revenues = new Array(7).fill(0);
    this.trends = new Array(7).fill(0);
  }

  ngOnInit(): void {
    this.updateChartData();  // Tự động gọi khi khởi tạo component
  }

  // Cập nhật dữ liệu khi người dùng chọn ngày mới
  onDateChange(event: any): void {
    const newDate = event.target.value;
    if (newDate) {
      this.selectedDate = newDate;
      this.updateChartData();  // Gọi lại API với ngày mới
    }
  }

  // Cập nhật dữ liệu biểu đồ dựa trên ngày được chọn
  updateChartData(): void {
    // Nếu người dùng không chọn ngày, mặc định là ngày 27 của tháng hiện tại
    const startDate = this.selectedDate ? new Date(this.selectedDate) : new Date();
    if (!this.selectedDate) {
      startDate.setDate(27); // Đặt ngày mặc định là ngày 27 của tháng hiện tại
    }

    const promises: Promise<any>[] = [];

    for (let i = 0; i < 7; i++) {
      const date = new Date(startDate);
      date.setDate(startDate.getDate() - i);

      const formattedDate = this.formatDate(date);

      promises.push(
        this.dailycashservice.getcash(formattedDate).toPromise()
      );
    }

    Promise.all(promises)
      .then(responses => {
        responses.forEach((response, index) => {
          this.revenues[6 - index] = response?.cashReceived || 0;
          this.trends[6 - index] = this.calculateTrend(index);
        });

        this.series = [
          {
            name: 'Doanh thu',
            type: 'column',
            data: this.revenues
          },
          {
            name: 'Xu hướng',
            type: 'line',
            data: this.trends
          }
        ];
      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }

  // Định dạng ngày theo kiểu yyyy-mm-dd
  formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = ('0' + (date.getMonth() + 1)).slice(-2);
    const day = ('0' + date.getDate()).slice(-2);
    return `${year}-${month}-${day}`;
  }

  calculateTrend(index: number): number {
    return this.revenues[index] + (Math.random() * 200 - 100);
  }
}
