# BookChallengeAPI (Work In Progress)

API that tracks book challenges and exposes the following endpints:

- GET /api/challenges - returns all challenges and books associated with each challenge
- GET /api/challenges/{challengeId} - retrive a specific challenge by challengeId

- GET /api/challenges/{challengeId}/books - retrieve books for a specifc challenge
- GET /api/challenges/{challengeId}/books/{bookId} - retrieve a specific book for a specific challenge

- POST /api/challenges/{challengeId}/books - add a new book to a specific challenge

Solution has 2 projects, the BookChallengeAPI under /src and BookChallenge.Test under /test

- to run the API from the command line, run 'dotnet run' in the /src/BookChallengeAPI directory
- to run the tests, run 'dotnet test' in the /src/BookChallengeAPI directory
