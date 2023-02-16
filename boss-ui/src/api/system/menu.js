import request from '@/utils/request'

// 查询菜单列表
export function listMenu(query) {
  return request({
    url: '/v1/Menu/GetList',
    method: 'post',
    data: query
  })
}

// 查询菜单详细
export function getMenu(menuId) {
  return request({
    url: '/v1/Menu/' + menuId,
    method: 'get'
  })
}

// 查询菜单下拉树结构
export function treeselect(appCode) {
  return request({
    url: '/v1/Menu/GetTreeSelect/',
    method: 'get',
    params:{'appCode':appCode}
  })
}

// 根据角色ID查询菜单下拉树结构
export function roleMenuTreeselect(roleId,appCode) {
  return request({
    url: '/v1/Menu/GetRoleMenus',
    method: 'post',
    data:{'roleId':roleId,'appCode':appCode}
  })
}

// 新增菜单
export function addMenu(data) {
  return request({
    url: '/v1/Menu',
    method: 'post',
    data: data
  })
}

// 修改菜单
export function updateMenu(data) {
  return request({
    url: '/v1/Menu',
    method: 'put',
    data: data
  })
}

// 删除菜单
export function delMenu(menuId) {
  return request({
    url: '/v1/Menu/' + menuId,
    method: 'delete'
  })
}
