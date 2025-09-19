import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StockHistoryComponent } from './stock-history/stock-history.component'
import { WeatherComponent } from './weather/weather.component'

const routes: Routes = [
  { path: 'stock-history', component: StockHistoryComponent },
  { path: 'weather', component: WeatherComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
