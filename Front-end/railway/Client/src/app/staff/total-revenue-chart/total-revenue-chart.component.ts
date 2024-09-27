import { Component, inject, OnInit } from '@angular/core';
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
import { DailycashService } from '../../services/dailycash.service';
@Component({
  selector: 'app-total-revenue-chart',
  standalone : true,
  imports:[NgApexchartsModule,CommonModule],
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
  public plotOptions: ApexPlotOptions;

  public currentYear: number=0;
  public days: string[]=[];
  public revenues: number[]=[];
  constructor() {
    this.series = [
    ];
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
      max: 2000
    };

    this.title = {
      text: 'Total Revenue',
      align: 'left'
    };

    this.legend = {
      position: 'top',
      horizontalAlign: 'left'
    };
    this.days = ['Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa', 'Su']; // Các ngày trong tuần
    this.revenues = []; // Mảng lưu trữ tổng thu nhập cho mỗi ngày
  }
  ngOnInit(): void {
    this.updateChartData();  // Gọi API khi component khởi tạo
  }

  // Gọi API cho từng ngày trong tuần và cập nhật dữ liệu biểu đồ
  updateChartData(): void {
    const today = new Date();
    this.revenues = []; // Khởi tạo mảng trống cho doanh thu mỗi ngày

    for (let i = 0; i < 7; i++) {
      const date = new Date(today);
      date.setDate(today.getDate() - i); // Lùi lại i ngày so với hôm nay

      const formattedDate = this.formatDate(date); // Định dạng ngày theo API

      this.dailycashservice.getcash(formattedDate)
        .subscribe(response => {
          this.revenues[i] = response.cashReceived || 0; // Cập nhật doanh thu cho ngày đó

          // Sau khi đã lấy đủ dữ liệu cho tất cả các ngày, cập nhật biểu đồ
          if (this.revenues.length === 7) {
            this.series = [
              {
                name: `${this.currentYear}`,
                data: this.revenues.reverse()  // Đảo ngược mảng để hiển thị từ thứ Hai đến Chủ Nhật
              }
            ];
          }
        }, error => {
          console.error(`Error fetching data for ${formattedDate}`, error);  // Xử lý lỗi nếu API trả về lỗi
        });
    }
  }

  // Định dạng ngày theo kiểu yyyy-mm-dd (phụ thuộc vào API)
  formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = ('0' + (date.getMonth() + 1)).slice(-2); // Thêm 0 vào trước nếu tháng < 10
    const day = ('0' + date.getDate()).slice(-2); // Thêm 0 vào trước nếu ngày < 10
    return `${year}-${month}-${day}`;
  }
}
