import { CommentFilm } from "./commentFilm";
import { VoteFilm } from "./voteFilm";
import { EmailValidator } from "@angular/forms";

export class User{
        public id?: number;
        public username: string;
        public email: string;
        public comments?: CommentFilm[];
        public votes?: VoteFilm[];
}