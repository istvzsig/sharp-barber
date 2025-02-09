import { Component } from '@angular/core';
import { VideoBackgroundComponent } from "../video-background/video-background.component";
import { ScissorsComponent } from "../scissors/scissors.component";
import { FooterComponent } from "../footer/footer.component";

@Component({
  selector: 'app-home',
  imports: [VideoBackgroundComponent, ScissorsComponent, FooterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

}
