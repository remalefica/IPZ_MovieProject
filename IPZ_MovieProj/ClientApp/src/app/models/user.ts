import { CommentFilm } from "./commentFilm";
import { VoteFilm } from "./voteFilm";

export class User{
        public id?: number;
        public username: string;
        public comments: CommentFilm[];
        public votes: VoteFilm[];
}