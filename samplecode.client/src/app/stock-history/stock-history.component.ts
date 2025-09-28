import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service'

interface StockHistory {
  id: number;
  ticker: string;
  date: string;
  open: number;
  high: number;
  low: number;
  close: number;
  adjClose: number;
  volume: number; 
}

@Component({
  selector: 'stock-history',
  standalone: false,
  templateUrl: './stock-history.component.html',
  styleUrl: './stock-history.component.css'
})
export class StockHistoryComponent implements OnInit {
  public stocks: StockHistory[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getStockHistory().subscribe(
      (response) => {
        this.stocks = response;
        console.log('Data from API:', this.stocks);
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }

  title = 'Stock Info'; 
}
