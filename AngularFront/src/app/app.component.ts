import { HttpClient } from '@angular/common/http';
import {HttpClientModule} from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { CepDictionary } from './cepDictionary';

import { of } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})


// implments onInit usado para teste rapido de função
export class AppComponent implements OnInit {
}
