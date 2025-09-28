import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-weather',
  standalone: false,
  templateUrl: './weather.component.html',
  styleUrl: './weather.component.css'
})
export class WeatherComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.apiService.getWeather().subscribe(
      (response) => {
        this.forecasts = response;
        console.log('Data from API:', this.forecasts);
      },
      (error) => {
        console.error('Error fetching data:', error);
      }
    );
  }

  title = 'Weather Info';
}
