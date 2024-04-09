// Rodar utilizando Mongosh (npm i mongosh -g)
// Ex: mongosh CreateBase.js
const database = 'KnightsChallengeDB';
const KnightsCollection = 'KnightsCollection';
const HallOfHeroesCollection = 'HallOfHeroesCollection';

use(database);
db.createCollection(KnightsCollection);
db.createCollection(HallOfHeroesCollection);