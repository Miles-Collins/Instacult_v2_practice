import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {import('./models/Cult').Cult.js[]} */
  cults: [],
    /** @type {import('./models/Cult').Cult.js|null} */
  activeCult: null,
    /** @type {import('./models/Cultist').Cultist.js[]} */
  cultist: [],
})
