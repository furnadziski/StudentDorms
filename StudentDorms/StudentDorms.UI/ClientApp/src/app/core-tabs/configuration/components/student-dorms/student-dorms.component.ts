import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';

import {MatExpansionModule} from '@angular/material/expansion';

@Component({
  selector: 'app-studentdorms',
  templateUrl: './student-dorms.component.html',
  styleUrls: ['./student-dorms.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class StudentdormsComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


}


