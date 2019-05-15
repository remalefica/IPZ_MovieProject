import { CommentFilm } from "./commentFilm";
import { VoteFilm } from "./voteFilm";

export class User{
    constructor(
        public id?: number,
        public username?: string,
        public userImgPath?: string,
        public comments?: CommentFilm[],
        public votes?: VoteFilm[],
    ){}
}