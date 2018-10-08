import { Component, Inject, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { setTimeout } from 'timers';
var $ = require('jquery');
var dt = require('datatables.net');

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['../app.component.css', '../../../node_modules/datatables.net-dt/css/jquery.datatables.css']
})
export class FetchDataComponent implements OnInit {
  public jobs: Job[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Job[]>(baseUrl + 'api/JobSearch/JobSearches').subscribe(
      (jobsearch: Job[]) => this.jobs = jobsearch,
         error => console.error(error));
    }
   
  ngOnInit() {
    setTimeout(function () {
      $('#JobsTable').DataTable();
    },3000);
  }
}

interface Job {
  id: string
  created_at: string
  title: string
  location: string
  type: string
  description: string
  how_to_apply: string
  company: string
  company_url: string
  company_logo: string
  url: string
}
