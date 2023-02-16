import request from '@/utils/request'

// 查询应用列表
export function listApp(query) {
  return request({
    url: '/v1/AppSecret/GetPageList',
    method: 'post',
    data: query
  })
}

// 查询应用详细
export function getApp(id) {
  return request({
    url: '/v1/AppSecret/' + id,
    method: 'get'
  })
}

// 新增应用
export function addApp(data) {
  return request({
    url: '/v1/AppSecret/',
    method: 'post',
    data: data
  })
}

// 修改应用
export function updateApp(data) {
  return request({
    url: '/v1/AppSecret/',
    method: 'put',
    data: data
  })
}
