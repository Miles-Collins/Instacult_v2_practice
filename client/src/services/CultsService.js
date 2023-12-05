import { AppState } from "../AppState.js";
import { Cultist } from "../models/Account.js";
import { Cult } from "../models/Cult.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class CultsService {

  async getCults() {
    const res = await api.get('api/cults')
    logger.log('[CULTS]', res.data)
    AppState.cults = res.data.map((cult) => new Cult(cult))
  }

  async getCultById(cultId) {
    const res = await api.get(`api/cults/${cultId}`)
    logger.log('[ACTIVE CULT]', res.data)
    AppState.activeCult = new Cult(res.data)
  }

  async getCultist(cultId) {
    const res = await api.get(`api/cults/${cultId}/cultMembers`)
    logger.log('[CULTIST]', res.data)
    AppState.cultist = res.data.map((cultist) => new Cultist(cultist))
  }

  setActiveCult(cult) {
    AppState.activeCult = new Cult(cult)
  }



}

export const cultsService = new CultsService();
