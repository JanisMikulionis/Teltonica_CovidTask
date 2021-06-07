import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChartComponent } from './chart/chart.component';
import { DataTableComponent } from './data-table/data-table.component';
import { FiltersFormComponent } from './filters-form/filters-form.component';
import { HomeComponent } from './home/home.component';
import { NewdataformComponent } from './newdataform/newdataform.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'data-table', component: DataTableComponent},
  {path: 'filters', component: FiltersFormComponent},
  {path: 'charts', component: ChartComponent},
  {path: 'newdataform', component: NewdataformComponent},
  {path: 'home', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
