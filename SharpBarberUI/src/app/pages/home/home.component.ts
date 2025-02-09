import { Component } from '@angular/core';
import { VideoBackgroundComponent } from '../../video-background/video-background.component';
import { ScissorsComponent } from '../../scissors/scissors.component';

@Component({
  selector: 'app-home',
  imports: [VideoBackgroundComponent, ScissorsComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

}
